import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import axios from "axios";
import { useEffect, useState } from "react";
import { CreateRoutineRequest } from "@/types/CreateRoutineRequest";
import { RoutineResponse } from "@/types/RoutineResponse";
import { Link } from "react-router-dom";

const formSchema = z.object({
  name: z.string().min(2).max(50),
  durationInBlocks: z.coerce.number(),
  workoutDaysPerBlock: z.coerce.number(),
});

function getRoutinesFromApi() {
  return axios
    .get<RoutineResponse[]>("/api/routines")
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      console.error(error);
      return [];
    });
}
export default function Home() {
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: "",
      durationInBlocks: 0,
      workoutDaysPerBlock: 0,
    },
  });

  const [routines, setRoutines] = useState<RoutineResponse[]>([]);

  useEffect(() => {
    getRoutinesFromApi().then((data) => {
      setRoutines(data);
    });
  }, []);

  async function onSubmit(values: z.infer<typeof formSchema>) {
    const requestBody: CreateRoutineRequest = {
      name: values.name,
      durationInBlocks: values.durationInBlocks,
      workoutDaysPerBlock: values.workoutDaysPerBlock,
    };

    const response = await axios.post("/api/routines", requestBody);

    if (response.status === 201) {
      getRoutinesFromApi().then((data) => {
        setRoutines(data);
      });
    }
  }
  return (
    <>
      <section className="mt-12 max-w-xl mx-auto">
        <h1 className="text-xl">Create Routine</h1>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8 ">
            <FormField
              control={form.control}
              name="name"
              render={({ field }) => (
                <FormItem className="mt-8">
                  <FormLabel>Routine Name</FormLabel>
                  <FormControl>
                    <Input {...field} required />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <div className="flex gap-8">
              <FormField
                control={form.control}
                name="durationInBlocks"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Weeks/Blocks</FormLabel>
                    <FormControl>
                      <Input
                        {...field}
                        type="number"
                        className="max-w-[100px]"
                        required
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="workoutDaysPerBlock"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Days per block</FormLabel>
                    <FormControl>
                      <Input
                        {...field}
                        type="number"
                        className="max-w-[100px]"
                        required
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
            <Button className="w-full sm:w-[200px]" type="submit">
              Create
            </Button>
          </form>
        </Form>
      </section>

      <section className="mt-12 max-w-xl mx-auto">
        <h2 className="text-l">Routine List</h2>
        <section className="mt-8">
          {routines.map((routine) => (
            <div className="w-full" key={routine.id}>
              <Link
                to={`/routines/${routine.id}`}
                className="mx-auto block w-full sm:w-auto sm:max-w-md text-primary underline-offset-4 hover:underline hover:cursor-pointer p-2 text-center shadow-md"
              >
                {routine.name}
              </Link>
            </div>
          ))}
        </section>
      </section>
    </>
  );
}
