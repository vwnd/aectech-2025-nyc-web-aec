import type { BridgeMessage } from "@/lib/types";
import { useState } from "react";
import { Button } from "./ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "./ui/card";
import { Input } from "./ui/input";
import { Label } from "./ui/label";

export default function UIMessagesHost() {
  const [text, setText] = useState("");

  const onSend = () => {
    if (text.trim() === "") return;
    const message: BridgeMessage = {
      type: "create:text",
      data: text,
    };

    if (!window.chrome.webview) throw new Error("WebView is not available");
    window.chrome.webview.postMessage(message);
  };

  return (
    <div className="flex flex-col min-h-screen items-center justify-center">
      <Card className="min-w-sm">
        <CardHeader>
          <CardTitle>Message</CardTitle>
          <CardDescription>Creates a text in the host app.</CardDescription>
        </CardHeader>
        <CardContent className="gap-4">
          <Label htmlFor="input-field" className="mb-2">
            Text Message
          </Label>
          <Input value={text} onChange={(e) => setText(e.target.value)} />
        </CardContent>
        <CardFooter>
          <Button onClick={onSend} className="">
            Send
          </Button>
        </CardFooter>
      </Card>
    </div>
  );
}
