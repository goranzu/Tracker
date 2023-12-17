import { useState } from "react";
import { Button } from "./components/ui/button";

function App() {
  const [showMessage, setShowMessage] = useState(false);

  return (
    <main className="container">
      <section className="mt-12 text-center">
        <Button onClick={() => setShowMessage(!showMessage)}>Click Me</Button>
        {showMessage && (
          <h1 className="mt-4 text-4xl font-semibold underline">Hello World</h1>
        )}
      </section>
    </main>
  );
}

export default App;
