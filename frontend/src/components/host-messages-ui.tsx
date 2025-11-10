import type { WebViewEventListener } from "@/webview";
import { useState } from "react";
import PropertiesTable from "./properties-table";
import { Empty, EmptyDescription, EmptyHeader, EmptyTitle } from "./ui/empty";

interface Selection {
  id: string;
  properties: Record<string, string>;
}

export default function HostMessagesUIApp() {
  const [selection, setSelection] = useState<Selection[]>([]);

  if (!window.chrome.webview) {
    return (
      <Empty>
        <EmptyHeader>
          <EmptyTitle>WebView not available</EmptyTitle>
          <EmptyDescription>
            This application must be run inside a WebView environment.
          </EmptyDescription>
        </EmptyHeader>
      </Empty>
    );
  }

  const listener: WebViewEventListener = (event) => {
    const message = event.data;
    setSelection(message.data);
    console.log("Received message from host:", message.type, message.data);
  };

  window.chrome.webview.addEventListener("message", listener);

  if (selection.length === 0) {
    return (
      <Empty>
        <EmptyHeader>
          <EmptyTitle>Nothing selected</EmptyTitle>
          <EmptyDescription>
            Please select an item to view its properties.
          </EmptyDescription>
        </EmptyHeader>
      </Empty>
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
