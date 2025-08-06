<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="410,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="430,225,120,_">
  <div class="onion-label view-transition-application-label">Application</div>
</v-drag>

<v-drag pos="450,330,80,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
FastEndpoints, on the other hand, looks to flip this relationship around by putting our application logic into the presentation layer.

The temptation to slide just a bit more code into an already busy handler that's already doing all the things kind of goes away.

At the very least, it gives us a simple decision to make as to whether this is presentation or application logic, or if it's logic that should really belong in the domain layer.

It becomes an either-or choice, and we're not busying up our thoughts with where to put DTOs and how we're mapping to and from them.

Now of course, there is a very real concern that with a typical controller setup, or even Minimal API, that we have a bunch of routes grouped together in a single class or file.

And if we're talking about moving all that application code into those routes, it's going to get messy, quickly.
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="120,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="210,265,160,160">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="230,195,120,_">
  <div class="onion-label view-transition-presentation-label" v-mark.orange.box="1">Presentation</div>
  <div class="onion-label view-transition-presentation-plus">+</div>
</v-drag>

<v-drag pos="230,225,120,_">
  <div class="onion-label view-transition-application-label" v-mark.purple.box="3">Application</div>
</v-drag>

<v-drag pos="250,330,80,_">
  <div class="onion-label view-transition-domain-label" data-id="domain">Domain</div>
</v-drag>

<v-drag pos="225,470,130,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="606,167,239,_">
  <div class="box view-transition-endpoint-box">
    <div v-mark.orange.box="2" class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div v-mark.purple.box="4" data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-click at="5">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
</v-click>

<v-click at="5">
  <FancyArrow q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
</v-click>

<!--
FastEndpoints addresses this by pushing us into a single endpoint per class approach.

Conceptually, our presentation layer becomes the code that describes our route. [click] [click]

And our application layer is covered by the handler for that endpoint. [click] [click] [click]

And what I've found is that by pushing a lot of the code right up to the presentation layer, it gives us the mental room to think a bit more critically about whether this is code that would make more sense being in the domain layer.
-->

---

<h1>Why?</h1>
<h2>How does FastEndpoints help with this?</h2>

<v-drag pos="40,175,239,_">
  <div class="box" data-id="ep1">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="260,175,239,_">
  <div class="box" data-id="ep2" v-mark.orange.box="1">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="480,175,239,_">
  <div class="box" data-id="ep3">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="700,175,239,_">
  <div class="box view-transition-endpoint-box" data-id="ep4">
    <div class="p-1">
      <p class="!mt-0 font-serif">Endpoint</p>
      <div class="text-placeholder w-80%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
    <hr/>
    <div data-id="handler" class="p-1">
      <p class="!mt-0 font-serif">Handler</p>
      <div class="text-placeholder w-70%"></div>
      <div class="text-placeholder w-100%"></div>
      <div class="text-placeholder w-90%"></div>
      <div class="text-placeholder w-40%"></div>
    </div>
  </div>
</v-drag>

<v-drag pos="430,160,112,_">
  <div v-click="1" class="floating-label text-xl color-orange" data-id="request">Request</div>
</v-drag>

<v-drag pos="430,485,112,_">
  <div v-click="2" class="floating-label text-xl color-orange" data-id="response">Response</div>
</v-drag>

<FancyArrow v-click="1" q1="[data-id=request]" q2="[data-id=ep2]" pos1="left" pos2="top" color="orange" arc="-0.15" head-size="20" class="z-100" />
<FancyArrow v-click="2" q1="[data-id=ep2]" q2="[data-id=response]" pos1="bottom" pos2="top-left" color="orange" arc="-0.15" head-size="20" class="z-100" />

<style>
  .box {
    scale: 70%;
  }
</style>

<!-- 
So, our typical controller gets broken up into a bunch of separate endpoints. [click]

Request comes in, gets mapped to an endpoint, we execute the code in our handler [click], and spit out the result.
 -->