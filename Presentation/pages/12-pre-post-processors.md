<h1>FastEndpoints</h1>
<h2 class="view-transition-title">Pre / Post Processors</h2>

<ul class="content">
  <li>A useful feature of MediatR is pre and post processors for cross-cutting concerns</li>
  <v-clicks>
    <li>FastEndpoints offers a similar feature to this in their own implementation of pre / post processors</li>
    <li>State can be shared between pre and post processors and endpoints</li>
    <li>Only one type of state can be used per request, leading to overloading of a single state object</li>
  </v-clicks>
</ul>

<!--
Anyone familiar with MediatR has probably used its pre- and post- processors, or pipeline behaviours, at some point.

FastEndpoints has an equivalent offering here [click], which allows us to run code before and after the endpoint handler is executed.

Where FastEndpoints' implementation is lacking however, is not having an easy way to handle both sides of the execution in a middleware-like fashion, such as MediatR offers with their pipeline behaviours.

[click]

We _do_ however have the ability to share state between all stages of the pipeline, although the implementation _is_ a little clunky to hold.

[click]

This is largely due to us needing to lean on an additional state object to share any values between the pre- and post- processors, meaning that while we can achieve the same functionality as a self-contained, start-to-finish MediatR pipeline behaviour, it's not quite as clean.
-->

---

<h1>FastEndpoints</h1>
<h2>Pre / Post Processors</h2>

<v-drag pos="40,175,239,_">
  <div v-click="1" class="box" data-id="pre-processor">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">PreProcessor&lt;TRequest, TState&gt;</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!my-0 font-serif">PreProcessAsync()</p>
    </div>
  </div>
</v-drag>

<FancyArrow v-click="1" q1="[data-id=pre-processor]" q2="[data-id=state]" pos1="bottom" pos2="left" color="gray" arc="-0.35" head-size="15" width="1" class="z-100">
  <span class="floating-label !text-xs bg-[#03060B]">Initialize&nbsp;state</span>
</FancyArrow>

<v-drag pos="260,175,239,_">
  <div class="box" data-id="endpoint" v-click="2">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">Endpoint&lt;TRequest&gt;</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!my-0 font-serif">HandleAsync()</p>
    </div>
  </div>
</v-drag>

<FancyArrow v-click="2" q1="[data-id=pre-processor]" q2="[data-id=endpoint]" pos1="right" pos2="left" color="pink" head-size="15" width="1" class="z-100" />

<FancyArrow v-click="2" q1="[data-id=endpoint]" q2="[data-id=state]" pos1="bottom" pos2="top-left" color="gray" arc="-0.15" head-size="15" width="1" class="z-100">
  <span class="floating-label !text-xs bg-[#03060B]">Add&nbsp;timings&nbsp;for&nbsp;specific&nbsp;actions</span>
</FancyArrow>

<v-drag pos="480,175,239,_">
  <div class="box" data-id="interceptor" v-click="3">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">IResponseInterceptor</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!my-0 font-serif">InterceptResponseAsync()</p>
    </div>
  </div>
</v-drag>

<FancyArrow v-click="3" q1="[data-id=endpoint]" q2="[data-id=interceptor]" pos1="right" pos2="left" color="pink" head-size="15" width="1" class="z-100" />

<FancyArrow v-click="3" q1="[data-id=state]" q2="[data-id=interceptor]" pos1="top-right" pos2="bottom" color="gray" arc="-0.15" head-size="15" width="1" class="z-100">
  <span class="floating-label !text-xs bg-[#03060B]">Add&nbsp;Server&nbsp;Timing&nbsp;header</span>
</FancyArrow>

<v-drag pos="700,175,239,_">
  <div class="box" data-id="post-processor" v-click="4">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">PostProcessor&lt;TRequest, TState, object&gt;</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!my-0 font-serif">PostProcessAsync()</p>
    </div>
  </div>
</v-drag>

<FancyArrow v-click="4" q1="[data-id=interceptor]" q2="[data-id=post-processor]" pos1="right" pos2="left" color="pink" head-size="15" width="1" class="z-100" />

<FancyArrow v-click="4" q1="[data-id=state]" q2="[data-id=post-processor]" pos1="right" pos2="bottom" color="gray" arc="-0.35" head-size="15" width="1" class="z-100">
  <span class="floating-label !text-xs bg-[#03060B]">Log&nbsp;total&nbsp;execution&nbsp;time</span>
</FancyArrow>

<v-drag pos="341,360,300,_">
  <div class="box" data-id="state" v-click="1" v-mark.orange.box="5">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">State</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">StartNewActivity(string name)</p>
      <p class="!mt-0 font-serif">GetTotalDuration()</p>
      <p class="!my-0 font-serif">ToServerTimingHeader()</p>
    </div>
  </div>
</v-drag>

<style>
  .box {
    scale: 70%;
  }
</style>

<!--
We'll see an example here however that shows how state can be accessed by various parts of the overall request pipeline, which does encourage separation of concern, as we can leverage the state being accessible across multiple parts of the entire pipeline.

[click]

First, our pre-processor initializes a class that represents our state, to in this case, track execution times.

[click]

Flow progresses to the endpoint, which can access the state object and, for example, attach specific timings to it for individual tasks.

[click]

This example uses a response interceptor, which is another feature of FastEndpoints &mdash; and required in this case &mdash; as post-processors are run _after_ the response has been sent, so if we want to add headers to, or modify the response, it needs to be done here.

[click]

And lastly, our post-processor picks up the same state object and simply logs the total execution time.

The clunkiness here [click] comes if we wanted to use a similar approach to, hypothetically, load user data from an easily injectable pre-processor, as we would have to add that user data as a property to our existing state object due to only being allowed to register one state object overall per request.

Overall however, we do have the ability to easily attach logic to either end of the request pipeline.

This example here is for a specific request, but we can just as easily register global pre- and post- processors as well.
-->
