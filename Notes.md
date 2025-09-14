1. just by adding @ in front of the template variable the serilog will be informed that we will like to serilize the object as json
createhandler and updatehandle have the above concepts demostrated

2.         [ProducesResponseType(statusCode: 200, Type = typeof(IEnumerable<RestaurantDto>))]
above code was added earlier in th application to inform swagger that the return type of the method is IEnumerable<RestaurantDto> but later was commented out as now the code in use is 
Task<ActionResult<IEnumerable<RestaurantDto>>>



