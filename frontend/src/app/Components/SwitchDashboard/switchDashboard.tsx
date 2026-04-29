'use client';

import { useState } from "react";

import ClassPerformance from "../Dashboards/Classperformance";
import StudentInsights from "../Dashboards/StudentInsight";
import Recommendations from "../Dashboards/Recommendations";

type DashboardType = "Class Performance" | "Student Insights" | "Recommendations";

export default function SwitchDashboard() {
    const [openDashboard, setOpenDashboard] = useState<DashboardType>("Class Performance");
    const [selectedStudentId, setSelectedStudentId] = useState<string | null>(null);

    const viewStudentInsight = (studentId: string) => {
        setSelectedStudentId(studentId);
        setOpenDashboard("Student Insights");
    };

    const renderDashboard = () => {
        switch (openDashboard) {
            case "Class Performance":
                return <ClassPerformance onViewStudent={viewStudentInsight} />;
            case "Student Insights":
                return <StudentInsights initialStudentId={selectedStudentId} />;
            case "Recommendations":
                return <Recommendations />;
            default:
                return <ClassPerformance onViewStudent={viewStudentInsight} />;
        }
    };

    const menuItems: { name: DashboardType; icon: string; subtitle: string }[] = [
        { name: "Class Performance", icon: "👥", subtitle: "Overview" },
        { name: "Student Insights", icon: "🧠", subtitle: "Learning Insights" },
        { name: "Recommendations", icon: "🎯", subtitle: "Action Recommendations" },
    ];

    return (
        <div className="w-full">
            <div className="p-3 flex justify-center gap-2 mb-6">
                {menuItems.map((item) => (
                    <button
                        key={item.name}
                        onClick={() => {
                            setOpenDashboard(item.name);
                            if (item.name !== "Student Insights") {
                                setSelectedStudentId(null);
                            }
                        }}
                        className={`flex items-center gap-3 px-6 py-3 rounded-lg transition-all shadow ${openDashboard === item.name
                            ? "bg-highlightButton text-white font-semibold shadow-md"
                            : "bg-gray-100 text-gray-700 hover:bg-foreground"
                            }`}
                    >
                        <span className="text-xl">{item.icon}</span>
                        <div className="text-left">
                            <div className="font-semibold">{item.name}</div>
                            <div className={`text-xs ${openDashboard === item.name ? "text-blue-100" : "text-gray-500"
                                }`}>
                                {item.subtitle}
                            </div>
                        </div>
                    </button>
                ))}
            </div>

            <div className="w-full">
                {renderDashboard()}
            </div>
        </div>
    );
}