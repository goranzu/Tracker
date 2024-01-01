import { RoutineBlockResponse } from "./RoutineBlockResponse";

export interface RoutineDetailResponse {
  id: number;
  name: string;
  durationInBlocks: number;
  blocks: RoutineBlockResponse[];
}
