import SwitchDashboard from "./Components/SwitchDashboard/switchDashboard";

export default function Home() {
  return (
    <main className="flex flex-row w-full h-screen">
      <div className="flex-1 flex flex-col">
        <div className="m-5 bg-background font-sans rounded-2xl">
          <div className="w-full p-5 flex items-center rounded-2xl border border-grayoffsetColor shadow-sm">
            <h1 className="text-highlightButton text-2xl font-bold">Class dashboard 4.a</h1>
            <p className="text-muted-foreground text-black text-sm ml-auto">Last updated: xx. June 20xx</p>
          </div>
        </div>
        <SwitchDashboard />
      </div>
    </main>
  );
}