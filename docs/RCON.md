# How to execute RCON Commands via the BattleMetrics API

### Request

URL | Method | Authorization | Content | Content-Type
----|--------|---------------|---------|-------------
`https://api.battlemetrics.com/servers/$SERVER_ID/command` | POST | Bearer | [Content](#content) | `application/json`

### Content
```
{
   "data":{
      "type":"rconCommand",
      "attributes":{
         "command":"raw",
         "options":{
            "raw":"$COMMAND_NAME"
         }
      }
   }
}
```

### Definitions
`$SERVER_ID`: The BattleMetrics ID of your server.

`$COMMAND_NAME`: The name of the command you wish to execute.

### Finding undocumented endpoints
1. Navigate to your BattleMetrics RCON Dashboard
2. Open the Developer Console (Inspect Element)
3. Navigate to the `Network` tab in the Developer Console
4. Execute any command, or feature, and analyze the captured requests made by BattleMetrics in your `Network` tab.

You're looking for a request that follows the structure of [request](#request), everything else can be ignored. Please note that some slight variation may be possible.

### Disclaimer
Please make sure to test this out with harmless commands, something like "Server Info", or "Show Next Map", before proceeding further!
