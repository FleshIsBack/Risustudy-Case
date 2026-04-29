'use client';

import { useState } from "react";
import { api } from "../../Api/api";
import { StudentInsight } from "../../models/StudentInsight";

interface StudentInsightsProps {
    initialStudentId: string | null;
}

export default function StudentInsights({ initialStudentId }: StudentInsightsProps) {
    const [insight, setInsight] = useState<StudentInsight | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");

    async function fetchInsight(id: string) {
        try {
            setLoading(true);
            setError("");
            const data = await api.getStudentInsights(id);
            setInsight(data);
        } catch (err) {
            console.error(err);
            setError("Student insights not generated.");
            setInsight(null);
        } finally {
            setLoading(false);
        }
    }

    useState(() => {
        fetchInsight(initialStudentId ?? "00000000-0000-0000-0000-000000000001");
    });

    function getTrendIcon(trend: string) {
        switch (trend) {
            case 'improving': return '📈';
            case 'stable': return '➡️';
            case 'declining': return '📉';
            default: return '•';
        }
    }

    function getTrendColor(trend: string) {
        switch (trend) {
            case 'improving': return 'text-green-700';
            case 'stable': return 'text-highlightButton';
            case 'declining': return 'text-red-700';
            default: return 'text-gray-700';
        }
    }

    return (
        <div className="space-y-6 m-6 border border-grayoffsetColor rounded-2xl p-6 bg-background shadow-sm">
            <div className="flex items-center gap-3">
                <span className="text-3xl">🧠</span>
                <h2 className="text-3xl font-bold text-gray-900">Student Learning Insights</h2>
            </div>

            {loading && <div className="text-center py-8 text-highlightButton font-semibold">Loading...</div>}
            {error && <div className="text-center py-8 text-red-600">{error}</div>}

            {insight && !loading && (
                <>
                    <div className="bg-foreground border-2 border-highlightButton/30 rounded-lg p-6">
                        <div className="flex items-center gap-2 mb-3">
                            <span className="text-2xl">✨</span>
                            <h3 className="text-xl font-bold text-gray-900">{insight.name}</h3>
                        </div>
                        <span className="text-highlightButton font-semibold text-sm">AI Analysis:</span>
                        <p className="text-gray-700 mt-2">{insight.aiAnalysis}</p>
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="bg-red-50 border-2 border-red-200 rounded-lg p-6">
                            <div className="flex items-center gap-2 mb-3">
                                <span className="text-xl">⚠️</span>
                                <h4 className="font-bold text-red-900">Weak Topics</h4>
                            </div>
                            <ul className="space-y-2">
                                {insight.weakTopics.map((topic, i) => (
                                    <li key={i} className="flex items-center gap-2">
                                        <span className="w-2 h-2 bg-red-500 rounded-full"></span>
                                        <span className="text-gray-700">{topic}</span>
                                    </li>
                                ))}
                            </ul>
                        </div>

                        <div className="bg-green-50 border-2 border-green-200 rounded-lg p-6">
                            <div className="flex items-center gap-2 mb-3">
                                <span className="text-xl">✅</span>
                                <h4 className="font-bold text-green-900">Strong Topics</h4>
                            </div>
                            <ul className="space-y-2">
                                {insight.strongTopics.map((topic, i) => (
                                    <li key={i} className="flex items-center gap-2">
                                        <span className="w-2 h-2 bg-green-500 rounded-full"></span>
                                        <span className="text-gray-700">{topic}</span>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </div>

                    <div className="bg-blue-50 border-2 border-blue-200 rounded-lg p-6">
                        <h4 className="font-bold text-blue-900 mb-2">Recent Trend</h4>
                        <div className="flex items-center gap-2">
                            <span className="text-2xl">{getTrendIcon(insight.trend)}</span>
                            <span className={`text-lg font-semibold capitalize ${getTrendColor(insight.trend)}`}>
                                {insight.trend}
                            </span>
                        </div>
                    </div>
                </>
            )}
        </div>
    );
}