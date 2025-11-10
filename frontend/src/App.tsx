import HostMessagesUIApp from "./components/host-messages-ui";
import { ThemeProvider } from "./components/theme-provider";

function App() {
  return (
    <ThemeProvider defaultTheme="system" storageKey="vite-ui-theme">
      <HostMessagesUIApp />
    </ThemeProvider>
  );
}

export default App;
