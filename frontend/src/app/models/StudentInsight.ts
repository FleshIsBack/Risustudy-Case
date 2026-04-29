export interface StudentInsight {
    studentId: string;
    name: string;
    aiAnalysis: string;
    weakTopics: string[];
    strongTopics: string[];
    trend: string;
    lastUpdated: string;
}
