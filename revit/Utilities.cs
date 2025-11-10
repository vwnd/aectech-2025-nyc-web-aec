using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.DB;
using WebAecCommon;

namespace WebAecRevit;

public static class Utilities
{
    public static CommonElement ToCommonElement(this Element revitElement)
    {
        var properties = new Dictionary<string, string>();

        foreach (var item in revitElement.GetOrderedParameters())
        {
            properties[item.Definition.Name] = item.AsValueString();
        }

        return new CommonElement(revitElement.Id.ToString(), revitElement.Name, properties);
    }

    public static void CreateTextElement(string text)
    {
        Application.actionEventHandler.Raise(app =>
        {
            var uiDoc = app.ActiveUIDocument;
            if (uiDoc == null)
            {
                Debug.WriteLine("No ActiveUIDocument available to create text.");
                return;
            }

            var doc = uiDoc.Document;
            var view = uiDoc.ActiveView;

            if (view == null || view.IsTemplate)
            {
                Debug.WriteLine("Active view is not available or is a template; cannot place text.");
                return;
            }

            // Text notes are not supported in some views (e.g., many 3D views). Guard lightly.
            if (view.ViewType == ViewType.ThreeD)
            {
                Debug.WriteLine("Active view is 3D; skipping TextNote creation.");
                return;
            }

            // Find a TextNoteType to use
            var textNoteTypeId = new FilteredElementCollector(doc)
                .OfClass(typeof(TextNoteType))
                .Cast<TextNoteType>()
                .Select(t => t.Id)
                .FirstOrDefault();

            if (textNoteTypeId == null || textNoteTypeId == ElementId.InvalidElementId)
            {
                Debug.WriteLine("No TextNoteType found in document.");
                return;
            }

            var options = new TextNoteOptions(textNoteTypeId)
            {
                HorizontalAlignment = HorizontalTextAlignment.Left,
                VerticalAlignment = VerticalTextAlignment.Top
            };

            // Place near model origin. Units are internal feet.
            var point = new XYZ(0, 0, 0);

            using (var transaction = new Transaction(doc, "Create Text Element"))
            {
                transaction.Start();

                // Use empty string if null to avoid API exceptions.
                var content = text ?? string.Empty;
                _ = TextNote.Create(doc, view.Id, point, content, options);

                transaction.Commit();
            }
        });
    }
}