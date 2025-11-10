import type { WebViewEventListener } from "@/webview";
import { useEffect, useState } from "react";
import PropertiesTable from "./properties-table";

interface Selection {
  id: string;
  properties: Record<string, string>;
}

export default function HostMessagesUIApp() {
  const [selection, setSelection] = useState<Selection[]>([]);

  useEffect(() => {
    if (!window.chrome?.webview) return;

    const listener: WebViewEventListener = (event) => {
      setSelection(event.data.data);
      console.log("Received message from host:", event.data);
    };

    window.chrome.webview.addEventListener("message", listener);
    return () => {
      if (window.chrome.webview)
        window.chrome.webview.removeEventListener("message", listener);
    };
  }, []);

  if (!window.chrome.webview) {
    return (
      <div className="flex flex-col min-h-screen justify-center items-center">
        Can't find WebView
      </div>
    );
  }

  if (selection.length === 0) {
    return (
      <div className="flex flex-col min-h-screen justify-center items-center">
        <div>Nothing selected.</div>
      </div>
    );
  }

  return (
    <div className="p-4">
      <h2 className="text-md font-bold mb-4">Selected Items</h2>
      {selection.map((item) => (
        <div className="mb-4">
          <PropertiesTable
            key={item.id}
            id={item.id}
            properties={item.properties}
          />
        </div>
      ))}
    </div>
  );
}
