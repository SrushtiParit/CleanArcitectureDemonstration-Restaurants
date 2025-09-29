1. just by adding @ in front of the template variable the serilog will be informed that we will like to serilize the object as json
createhandler and updatehandle have the above concepts demostrated

2.         [ProducesResponseType(statusCode: 200, Type = typeof(IEnumerable<RestaurantDto>))]
above code was added earlier in th application to inform swagger that the return type of the method is IEnumerable<RestaurantDto> but later was commented out as now the code in use is 
Task<ActionResult<IEnumerable<RestaurantDto>>>

3. If we are implementing anything as middleware than have to inherit from IMiddleware interface and when you implement the interface you will be forced to implement the method InvokeAsync(HttpContext context, RequestDelegate next)
in that method you have to invooke the next (context) that is a delegate to pass the control to the next middleware in the pipeline




