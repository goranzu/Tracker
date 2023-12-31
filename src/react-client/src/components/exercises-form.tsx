import { data } from "@/data";
import { Button } from "./ui/button";
import { Input } from "./ui/input";
import { useState } from "react";

export default function ExercisesForm() {
  const [week, setWeek] = useState(1);
  return (
    <>
      <section className="max-w-3xl mt-12 flex justify-between items-center mx-auto">
        <Button
          onClick={() => {
            if (week <= 1) {
              return;
            }
            setWeek(week - 1);
          }}
        >
          Previous
        </Button>
        <p className="text-xl">Week {week}</p>
        <Button
          onClick={() => {
            setWeek(week + 1);
          }}
        >
          Next
        </Button>
      </section>
      <section className="max-w-3xl mx-auto">
        <form
          onSubmit={(e) => {
            e.preventDefault();
          }}
        >
          {data.map((exercise) => (
            <div className="mt-8" key={exercise.id}>
              <p className="text-xl underline">{exercise.exerciseName}</p>
              <div className="flex justify-between gap-4">
                <div className="mt-4">
                  <label
                    className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                    htmlFor={`sets-${exercise.id}`}
                  >
                    Sets
                  </label>
                  <Input type="number" />
                </div>
                <div className="mt-4">
                  <label
                    className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                    htmlFor={`reps-${exercise.id}`}
                  >
                    Reps
                  </label>
                  <Input type="number" />
                </div>
                <div className="mt-4">
                  <label
                    className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                    htmlFor={`weight-${exercise.id}`}
                  >
                    Weight
                  </label>
                  <Input type="number" />
                </div>
              </div>
            </div>
          ))}
        </form>
      </section>
    </>
  );
}
