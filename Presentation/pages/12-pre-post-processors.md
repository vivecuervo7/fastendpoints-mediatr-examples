<h1>FastEndpoints</h1>
<h2>Pre / Post Processors</h2>

<ul class="content">
  <li>A useful feature of MediatR is pipeline behaviours for cross-cutting concerns</li>
  <v-clicks>
    <li>FastEndpoints offers a similar feature to this in endpoint Pre / Post Processors</li>
    <li>State can be shared between Pre- and Post- Processors and Endpoints</li>
    <li>Only one type of state can be used per request, leading to overloading of a single state “bag”</li>
    <li>Not as clean as a start-to-finish MediatR pipeline behaviour due to needing separate classes coupled via that state object</li>
  </v-clicks>
</ul>

<!--
Anyone familiar with MediatR has probably used their pre- and post- processors at some point.

[click]

FastEndpoints has an equivalent offering here, which allows us to run code before and after the endpoint handler is executed.

Where FastEndpoints' implementation is lacking however, is not having an easy way to handle both sides of the execution in a middleware-like fashion as MediatR offers with their pipeline behaviours

[click]

We _do_ however have the ability to share state between all stages of the pipeline, although the implementation is a little clunky to hold.

[click]

If we do want to share any state, we need to lean on an additional state object to share any values between the pre- and post- processors [click], meaning that while we can achieve the same functionality, it's not as clean as a start-to-finish MediatR pipeline behaviour.
-->

---

<h1>FastEndpoints</h1>
<h2>Pre / Post Processors</h2>

<v-drag pos="40,175,239,_">
  <div v-click="1" class="box" data-id="pre-processor">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">Pre-processor</p>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!my-0 font-serif">PreProcessAsync()</p>
    </div>
  </div>
</v-drag>

<FancyArrow v-click="1" q1="[data-id=pre-processor]" q2="[data-id=state]" pos1="bottom" pos2="left" color="gray" arc="-0.35" head-size="15" width="1" class="z-100">
  <span class="floating-label !text-xs bg-[#03060B]">Initialize&nbsp;state&nbsp;bag</span>
</FancyArrow>

<v-drag pos="260,175,239,_">
  <div class="box" data-id="endpoint" v-click="2">
    <div class="p-1">
      <p class="!my-0 font-serif !font-bold">Endpoint</p>
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
      <p class="!my-0 font-serif !font-bold">Response Interceptor</p>
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
      <p class="!my-0 font-serif !font-bold">Post-processor</p>
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
We'll see an example here that shows how state can be accessed by various parts of the overall request pipeline, which encourages separation of concern, as we can leverage the state across multiple parts of the entire request pipeline.

[click]

First, our pre-processor initializes a state bag to, in this case, track execution times.

[click]

Flow progresses to the endpoint, which can access this and, for example, attach specific timings to it for individual tasks.

[click]

This example uses a response interceptor, which is another feature of FastEndpoints &mdash; and required in this case &mdash; as post- processors are run _after_ the response has been sent, so if we want to add headers to, or modify the response, it needs to be done here.

[click]

And lastly, our post- processor picks up the same state bag and simply logs the total execution time.

The clunkiness here [click] comes if we wanted to use a similar approach to, for example, load a user from our database in an easily injectable pre-processor, as we would have to add the user as a property to our existing state bag due to only being allowed to register a single state object.
-->
