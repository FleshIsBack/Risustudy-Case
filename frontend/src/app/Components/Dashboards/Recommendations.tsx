'use client';

import { useState } from "react";
import { api } from "../../Api/api";
import { Recommendation } from "../../models/Recommendation";

export default function Recommendations() {
    const [recommendations, setRecommendations] = useState<Recommendation[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");

    async function fetchRecommendations() {
        try {
            setLoading(true);
            setError("");
            const data = await api.getRecommendations();
            setRecommendations(data);
        } catch (err) {
            console.error(err);
            setError("Failed to load recommendations.");
        } finally {
            setLoading(false);
        }
    }

    useState(() => {
        fetchRecommendations();
    });

    function getPriorityColor(priority: string) {
        switch (priority) {
            case 'high': return 'bg-red-50 text-red-800 border-red-200';
            case 'medium': return 'bg-orange-50 text-orange-800 border-orange-200';
            case 'low': return 'bg-foreground text-highlightButton border-highlightButton/30';
            default: return 'bg-grayoffsetColor text-gray-800 border-gray-200';
        }
    }

    function getTypeIcon(type: string) {
        switch (type) {
            case 'intervention': return '🚨';
            case 'grouping': return '👥';
            case 'assignment': return '📝';
            case 'checkin': return '👀';
            default: return '•';
        }
    }

    function getPriorityIcon(priority: string) {
        switch (priority) {
            case 'high': return '🔴';
            case 'medium': return '🟡';
            case 'low': return '🟢';
            default: return '•';
        }
    }

    return (
        <div className="space-y-6 m-6 border border-grayoffsetColor rounded-2xl p-6 bg-background shadow-sm">
            <div className="flex items-center gap-3">
                <span className="text-3xl">🎯</span>
                <h2 className="text-3xl font-bold text-gray-900">Teacher Action Recommendations</h2>
            </div>

            {loading && <div className="text-center py-8 text-highlightButton font-semibold">Loading...</div>}
            {error && <div className="text-center py-8 text-red-600">{error}</div>}

            {!loading && !error && recommendations.length === 0 && (
                <div className="text-center py-12">
                    <span className="text-6xl mb-4 block">✅</span>
                    <p className="text-gray-500 text-lg">No recommendations at this time</p>
                    <p className="text-gray-400 text-sm mt-1">All students are on track!</p>
                </div>
            )}

            {recommendations.length > 0 && !loading && (
                <div className="space-y-4">
                    {recommendations.map(rec => (
                        <div
                            key={rec.id}
                            className="bg-background border-2 border-grayoffsetColor rounded-xl p-6 hover:shadow-md hover:border-highlightButton/20 transition-all"
                        >
                            <div className="flex items-start justify-between mb-3">
                                <div className="flex items-center gap-3">
                                    <span className="text-3xl">{getTypeIcon(rec.type)}</span>
                                    <div>
                                        <h3 className="font-bold text-lg text-gray-900">{rec.title}</h3>
                                        <span className={`px-3 py-1 rounded-full text-xs font-semibold border-2 inline-flex items-center gap-1 mt-1 ${getPriorityColor(rec.priority)}`}>
                                            <span>{getPriorityIcon(rec.priority)}</span>
                                            <span>{rec.priority.toUpperCase()} PRIORITY</span>
                                        </span>
                                    </div>
                                </div>

                                <div className="bg-foreground border border-highlightButton/20 rounded-lg px-4 py-2 text-center">
                                    <p className="text-xs text-gray-500">Expected Impact</p>
                                    <p className="text-highlightButton font-bold">{rec.expectedImpact}</p>
                                </div>
                            </div>

                            <p className="text-gray-700 mb-4 pl-12">{rec.description}</p>

                            <div className="flex flex-wrap items-center gap-2 pl-12">
                                <span className="text-sm font-semibold text-gray-600">Students:</span>
                                {rec.studentNames.map((name, i) => (
                                    <span
                                        key={i}
                                        className="bg-foreground text-highlightButton px-3 py-1 rounded-full text-sm border border-highlightButton/20 font-medium"
                                    >
                                        {name}
                                    </span>
                                ))}
                            </div>
                            <div className="mt-4 pl-12">
                                <button className="bg-highlightButton text-white px-6 py-2 rounded-lg hover:bg-highlightButton/80 font-semibold transition-colors text-sm">
                                    Take Action →
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}