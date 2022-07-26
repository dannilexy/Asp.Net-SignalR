//create connection
var connectionDeathlyHallows = new signalR.HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .withUrl("/hubs/DeathlyHallows").build();

var cloakCounter = document.getElementById("cloakCounter");
var stoneCounter = document.getElementById("stoneCounter");
var wandCounter = document.getElementById("wandCounter");


//connect to methods that hub invokes aka receive notfications from hub
connectionDeathlyHallows.on("updateDeathlyHallowsCount", (cloak, stone, wand) => {
   
    cloakCounter.innerText = cloak.toString();   
    stoneCounter.innerText = stone.toString();
    wandCounter.innerText = wand.toString();
    
   
});



//start connection
function fulfilled() {
    //do something on start
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {
        cloakCounter.innerText = raceCounter.cloak.toString();
        stoneCounter.innerText = raceCounter.stone.toString();
        wandCounter.innerText = raceCounter.wand.toString();
    })
    console.log("Connection to User Hub Successful");

}
function rejected() {
    //rejected logs
}
connectionDeathlyHallows.start().then(fulfilled, rejected);