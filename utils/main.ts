import * as signal from "https://unpkg.com/@microsoft/signalr@7.0.0/dist/esm/index.js";
const connection = new signal.HubConnectionBuilder().withUrl("/hub", {}).build();


connection.on("Ping", (data: string) => {
    console.log(data);
});

connection.start().then(async () => {
    await connection.invoke("Ping");
})

