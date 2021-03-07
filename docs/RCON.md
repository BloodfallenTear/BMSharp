# How to execute Commands via the BattleMetrics API

URL | Method | Authorization | Content | Content-Type
----|--------|---------------|---------|-------------
`https://api.battlemetrics.com/servers/$SERVER_ID/command` | POST | Bearer | See Content| `application/json`

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

### Disclaimer
Please make sure to test this out with harmless commands, something like "Server Info", or "Show Next Map", before proceeding further!