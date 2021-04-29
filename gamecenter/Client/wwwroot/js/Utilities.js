function myFunction(message) {
    console.log("from utilities", message)
}

function dotnetStaticInvocation() 
{
    DotNet.invokeMethodAsync("gamecenter.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from js" + result)
        });
}

function dotnetInstanceInvocation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}