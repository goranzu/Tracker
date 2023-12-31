import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/home";
import RoutineDetail from "./pages/routine-detail";

function App() {
  return (
    <Router>
      <main className="container">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/routines/:id" element={<RoutineDetail />} />
        </Routes>
      </main>
    </Router>
  );
}

export default App;
