import { JobPosition } from "./job-position";

export interface JobApplication {
    id: number;
    jobPositionId: number;
    jobPosition: JobPosition;
    applicantName: string;
    status: string;
}
