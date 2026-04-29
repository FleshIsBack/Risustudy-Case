export interface Recommendation {
    id: string;
    type: string;
    priority: string;
    title: string;
    description: string;
    studentNames: string[];
    expectedImpact: string;
    createdAt: string;
}