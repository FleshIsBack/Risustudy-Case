// lib/api.ts

import { ClassPerformanceData } from "../models/ClassPerformance";
import { Recommendation } from "../models/Recommendation";
import { StudentInsight } from "../models/StudentInsight";

const API_BASE_URL = 'https://backendapi20260429202502-a6g9a9fga0g4aygs.canadacentral-01.azurewebsites.net';

class ApiError extends Error {
    constructor(public status: number, message: string) {
        super(message);
        this.name = 'ApiError';
    }
}

async function apiFetch<T>(endpoint: string): Promise<T> {
    const url = `${API_BASE_URL}${endpoint}`;

    try {
        const response = await fetch(url);

        if (!response.ok) {
            throw new ApiError(response.status, `HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        return data as T;
    } catch (error) {
        if (error instanceof ApiError) {
            throw error;
        }
        console.error('API fetch error:', error);
        throw new Error('Failed to fetch data from API');
    }
}

export const api = {
    getClassPerformance: async (): Promise<ClassPerformanceData> => {
        return apiFetch<ClassPerformanceData>(`/api/classes/11111111-1111-1111-1111-111111111111/performance`);
    },

    getStudentInsights: async (studentId: string): Promise<StudentInsight> => {
        return apiFetch<StudentInsight>(`/api/students/${studentId}/insight`);
    },

    getRecommendations: async (): Promise<Recommendation[]> => {
        return apiFetch<Recommendation[]>(`/api/classes/11111111-1111-1111-1111-111111111111/recommendations`);
    },
};

