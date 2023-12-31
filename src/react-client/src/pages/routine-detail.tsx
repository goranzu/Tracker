import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import { RoutineDetailResponse } from "@/types/RoutineDetailResponse";

function getRoutineById(id: number) {
  return axios
    .get<RoutineDetailResponse>(`/api/routines/${id}`)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      console.error(error);
    });
}

export default function RoutineDetail() {
  const [routine, setRoutine] = useState<RoutineDetailResponse | null>(null);

  const params = useParams();

  useEffect(() => {
    if (params.id == null) {
      return;
    }

    getRoutineById(+params.id!).then((data) => {
      if (data) {
        setRoutine(data);
      }
    });
  }, [params.id]);

  return (
    <>
      {routine && (
        <section className="mt-12">
          <h1 className="text-xl">{routine.name}</h1>
          {routine.blocks.map((_, index) => (
            <div key={index} className="mt-8">
              <h1>Block {index + 1}</h1>
            </div>
          ))}
          {/* {Array.from({ length: routine.durationInBlocks }).map((_, index) => (
            <div key={index} className="mt-8">
              <h1>Block {index + 1}</h1>
            </div>
          ))} */}
        </section>
      )}
    </>
  );
}
