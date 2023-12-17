import { useState } from "react";
import { Button } from "./components/ui/button";
import * as z from "zod";
import { useForm, useFieldArray } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { data } from "./data";

const formSchema = z.object({
  exercises: z.array(
    z.object({
      sets: z.number(),
      reps: z.number(),
      weight: z.number(),
      exerciseName: z.string(),
    }),
  ),
});

function App() {
  const [week, setWeek] = useState(1);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      exercises: data.map((workout) => ({
        reps: workout.reps,
        sets: workout.sets,
        weight: workout.weight,
        exerciseName: workout.exerciseName,
      })),
    },
  });

  const { fields } = useFieldArray({
    name: "exercises",
    control: form.control,
  });

  function onSubmit(values: z.infer<typeof formSchema>) {
    console.log(values);
  }

  return (
    <main className="container">
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
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="space-y-8 mt-8"
          >
            {fields.map((exercise, index) => {
              return (
                <div key={exercise.id}>
                  <p className="text-xl">{exercise.exerciseName}</p>
                  <div className="flex justify-between gap-4">
                    <FormField
                      control={form.control}
                      name={`exercises.${index}.sets`}
                      render={({ field }) => (
                        <FormItem>
                          <FormLabel>Sets</FormLabel>
                          <FormControl>
                            <Input
                              {...field}
                              onChange={(e) => {
                                field.onChange(e);
                                console.log(
                                  `exercises.${index}.sets`,
                                  e.target.value,
                                );
                              }}
                            />
                          </FormControl>
                          <FormMessage />
                        </FormItem>
                      )}
                    />
                    <FormField
                      control={form.control}
                      name={`exercises.${index}.reps`}
                      render={({ field }) => (
                        <FormItem>
                          <FormLabel>Sets</FormLabel>
                          <FormControl>
                            <Input {...field} />
                          </FormControl>
                          <FormMessage />
                        </FormItem>
                      )}
                    />
                    <FormField
                      control={form.control}
                      name={`exercises.${index}.weight`}
                      render={({ field }) => (
                        <FormItem>
                          <FormLabel>Sets</FormLabel>
                          <FormControl>
                            <Input {...field} />
                          </FormControl>
                          <FormMessage />
                        </FormItem>
                      )}
                    />
                  </div>
                </div>
              );
            })}
            <Button type="submit">Submit</Button>
          </form>
        </Form>
      </section>
    </main>
  );
}

export default App;
