import { Student } from "./Student";

export interface ClassPerformanceData {
    classId: string;
    className: string;
    summary: {
        advancedCount: number;
        onTrackCount: number;
        needsAttentionCount: number;
        totalStudents: number;
    };
    students: Student[];
}