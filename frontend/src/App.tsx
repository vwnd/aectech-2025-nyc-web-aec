import HelloWorldApp from "./components/hello-world";
import { ThemeProvider } from "./components/theme-provider";

function App() {
  return (
    <ThemeProvider defaultTheme="system" storageKey="vite-ui-theme">
      <HelloWorldApp />
    </ThemeProvider>
  );
}

export default App;
