import ThemeToggle from "@/components/theme-toggle";
import { Button } from "@/components/ui/button";
import { useState } from "react";
import reactLogo from "./assets/react.svg";
import revitLogo from "./assets/revit.svg";
import rhinoLogo from "./assets/rhino.png";
import viteLogo from "/vite.svg";

export default function HelloWorldApp() {
  const [count, setCount] = useState(0);

  const host: string = "Rhino";
  let logo: string = reactLogo;
  switch (host) {
    case "Rhino":
      logo = rhinoLogo;
      break;
    case "Revit":
      logo = revitLogo;
      break;
    case "React":
    default:
      logo = reactLogo;
      break;
  }

  return (
    <div className="flex flex-col min-h-screen items-center justify-center">
      <div className="flex gap-18 mb-8">
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="size-42" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img
            src={logo}
            className="size-42 animate-[spin_10s_linear_infinite]"
            alt="Host logo"
          />
        </a>
      </div>
      <h1 className="text-6xl font-bold">Vite + {host}</h1>
      <div className="flex flex-col items-center gap-4 mt-8">
        <div className="flex gap-4">
          <Button onClick={() => setCount((count) => count + 1)}>
            Count is {count}
          </Button>
          <ThemeToggle />
        </div>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
    </div>
  );
}
