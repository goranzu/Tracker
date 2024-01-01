import { WorkoutDayResponse } from "./WorkoutDayResponse";

export interface RoutineBlockResponse {
  id: number;
  blockNumber: number;
  routineId: number;
  workoutDays: WorkoutDayResponse[];
}
