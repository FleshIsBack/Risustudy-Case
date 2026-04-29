'use client';

import { useState } from "react";
import { api } from "./../../Api/api";
import { ClassPerformanceData } from "../../models/ClassPerformance";

interface ClassPerformanceProps {
    onViewStudent: (studentId: string) => void;
}

export default function ClassPerformance({ onViewStudent }: ClassPerformanceProps) {
    const [data, setData] = useState<ClassPerformanceData | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");

    async function fetchData() {
        try {
            setLoading(true);
            setError("");
            const result = await api.getClassPerformance();
            setData(result);
        } catch (err) {
            console.error(err);
            setError("Failed to load class performance.");
        } finally {
            setLoading(false);
        }
    }

    useState(() => {
        fetchData();
    });

    function getStatusColor(status: string) {
        switch (status) {
            case 'advanced': return 'bg-green-50 text-green-800 border-green-200';
            case 'ontrack': return 'bg-foreground text-highlightButton border-highlightButton/30';
            case 'needsattention': return 'bg-orange-50 text-orange-800 border-orange-200';
            default: return 'bg-grayoffsetColor text-gray-800 border-gray-200';
        }
    }

    function getStatusIcon(status: string) {
        switch (status) {
            case 'advanced': return '📈';
            case 'ontrack': return '✅';
            case 'needsattention': return '⚠️';
            default: return '❓';
        }
    }

    function getProgressBarColor(status: string) {
        switch (status) {
            case 'advanced': return 'bg-green-500';
            case 'on-track': return 'bg-highlightButton';
            case 'needs-attention': return 'bg-orange-500';
            default: return 'bg-gray-400';
        }
    }

    return (
        <div className="space-y-6 m-6 border border-grayoffsetColor rounded-2xl p-6 bg-background shadow-sm">
            <div className="flex items-center gap-3">
                <span className="text-3xl">📊</span>
                <h2 className="text-3xl font-bold text-gray-900">Class Performance Overview</h2>
            </div>

            {loading && <div className="text-center py-8 text-highlightButton font-semibold">Loading...</div>}
            {error && <div className="text-center py-8 text-red-600">{error}</div>}

            {data && !loading && (
                <>
                    <div className="grid grid-cols-3 gap-4">
                        <div className="bg-green-50 border-2 border-green-200 rounded-lg p-6 hover:shadow-md transition-shadow">
                            <div className="flex items-center justify-between">
                                <div>
                                    <p className="text-green-600 text-sm font-semibold">Advanced</p>
                                    <p className="text-4xl font-bold text-green-900">{data.summary.advancedCount}</p>
                                </div>
                                <span className="text-4xl">📈</span>
                            </div>
                        </div>

                        <div className="bg-foreground border-2 border-highlightButton/30 rounded-lg p-6 hover:shadow-md transition-shadow">
                            <div className="flex items-center justify-between">
                                <div>
                                    <p className="text-highlightButton text-sm font-semibold">On Track</p>
                                    <p className="text-4xl font-bold text-highlightButton">{data.summary.onTrackCount}</p>
                                </div>
                                <span className="text-4xl">✅</span>
                            </div>
                        </div>

                        <div className="bg-orange-50 border-2 border-orange-200 rounded-lg p-6 hover:shadow-md transition-shadow">
                            <div className="flex items-center justify-between">
                                <div>
                                    <p className="text-orange-600 text-sm font-semibold">Needs Attention</p>
                                    <p className="text-4xl font-bold text-orange-900">{data.summary.needsAttentionCount}</p>
                                </div>
                                <span className="text-4xl">⚠️</span>
                            </div>
                        </div>
                    </div>

                    <div className="space-y-3">
                        {data.students.map(student => (
                            <div
                                key={student.id}
                                onClick={() => onViewStudent(student.id)}
                                className="bg-background border-2 border-grayoffsetColor rounded-lg p-4 hover:shadow-md hover:border-highlightButton/50 transition-all cursor-pointer"
                            >
                                <div className="flex items-center justify-between">
                                    <div className="flex items-center gap-4">
                                        <div>
                                            <h3 className="font-bold text-gray-900">{student.name}</h3>
                                            <span className={`px-3 py-1 rounded-full text-xs font-semibold border-2 inline-flex items-center gap-1 mt-1 ${getStatusColor(student.status)}`}>
                                                <span>{getStatusIcon(student.status)}</span>
                                                <span>{student.status.toUpperCase()}</span>
                                            </span>
                                        </div>
                                    </div>

                                    <div className="flex items-center gap-4">
                                        <div className="text-right">
                                            <p className="text-sm text-gray-600">Progress</p>
                                            <p className="text-2xl font-bold text-gray-900">{student.progress}%</p>
                                        </div>
                                        <div className="w-32 bg-grayoffsetColor rounded-full h-3 border border-gray-200">
                                            <div
                                                className={`h-3 rounded-full transition-all ${getProgressBarColor(student.status)}`}
                                                style={{ width: `${student.progress}%` }}
                                            />
                                        </div>
                                        <span className="text-highlightButton text-xl opacity-50 hover:opacity-100 transition-opacity">→</span>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                </>
            )}
        </div>
    );
}