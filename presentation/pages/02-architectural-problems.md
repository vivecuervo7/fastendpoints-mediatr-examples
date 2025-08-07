<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="370,225,240,240">
  <div class="onion-application onion-circle view-transition-application"></div>
</v-drag>

<v-drag pos="425,280,130,130">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label" data-id="presentation">Presentation</div>
</v-drag>

<v-drag pos="430,245,120,_">
  <div class="onion-label view-transition-application-label" data-id="application">Application</div>
</v-drag>

<v-drag pos="450,330,80,_">
  <div class="onion-label view-transition-domain-label" data-id="domain" v-mark.blue.box="10">Domain</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="160,172,112,_">
  <div v-click="1" class="floating-label" data-id="request-dto" v-mark.blue.circle="[9,10]">Request DTO</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=request-dto]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="114,206,96,_">
  <div v-click="1" class="floating-label" data-id="controller">Controller</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=controller]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="629,177,120,_">
  <div v-click="1" class="floating-label" data-id="response-dto" v-mark.blue.circle="[9,10]">Response DTO</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=response-dto]" pos1="top-right" pos2="left" color="orange" arc="0.075" head-size="20" class="z-100" />

<v-drag pos="22,327,141,_">
  <div v-click="2" class="floating-label" data-id="query">Query / Command</div>
</v-drag>
<FancyArrow v-click="2" q1="[data-id=application]" q2="[data-id=query]" pos1="left" pos2="top-right" color="orange" arc="-0.15" head-size="20" class="z-100" />

<v-drag pos="192,461,88,_">
  <div v-click="5" class="floating-label" data-id="mediator">MediatR</div>
</v-drag>
<FancyArrow v-click="5" q1="[data-id=application]" q2="[data-id=mediator]" pos1="bottom-left" pos2="top" color="red" arc="-0.25" head-size="20" class="z-100" />

<v-drag pos="803,307,81,_">
  <div v-click="3" class="floating-label" data-id="handler" v-mark.blue.circle="[8,10]">Handler</div>
</v-drag>
<FancyArrow v-click="3" q1="[data-id=application]" q2="[data-id=handler]" pos1="right" pos2="top-left" color="orange" arc="0.1" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="top-right" color="purple" head-size="20" class="z-100" />

<FancyArrow v-click="2" q1="[data-id=controller]" q2="[data-id=query]" pos1="bottom" pos2="top" color="teal" arc="-0.2" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="5" q1="[data-id=query]" q2="[data-id=mediator]" pos1="bottom" pos2="top-left" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="6" q1="[data-id=mediator]" q2="[data-id=handler]" pos1="bottom" pos2="bottom" color="red" arc="-0.375" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="7" q1="[data-id=handler]" q2="[data-id=response-dto]" pos1="top" pos2="right" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />

<FancyArrow v-click="10" q1="[data-id=domain]" q2="[data-id=application]" pos1="top" pos2="bottom" color="blue" head-size="20" class="z-100" />

<!--
Now, most people are going to be at least somewhat familiar with a diagram similar to this one.

In a typical application, particularly one using DDD, we would aim to separate our code into presentation, application, domain and infrastructure layers.

Which is great, and we're all used to it.

Still, there are a lot of moving parts that can make things feel a bit overwhelming.

I'll quickly run through those moving parts, and put a lot of busy arrows on the screen to make it look as terrible as possible.

We have our presentation layer which is responsible for the request and response DTOs [click], serialization and returning errors.

Then we have queries and commands housed in our application layer [click], along with our handlers [click].

Our handlers are then in turn responsible for reaching into the domain and infrastructure layers [click], and essentially coordinating the business logic for our application.

And then we throw MediatR into the mix [click], glueing together our commands and queries to their respective handlers [click], which are then responsible for outputting a result that can be turned into a response DTO [click].

Assuming, of course, that we haven't just exposed those DTOs to the handlers themselves to make our lives easier.

Ultimately, what I've observed is that with this many moving parts, that a disproportionate amount of logic ends up in the handlers. [click]

While there's a fair amount of speculation at play, I consider this to be the result of having too many places for code to live.

We make decisions hard for ourselves, and we make code cumbersome to write.

And so, we cut corners, and we find the easiest place to put code.

More often than not, I see this presented as the handlers in our application layer becoming the God of all our logic.

Almost invariably, I've seen them being made aware of, or even "owning" the request and response DTOs. [click]

And honestly, I don't mind this one all that much.

It's pragmatic.

That said, at best it's still increasing the surface area for disagreement.

The thing I've noticed that doesn't sit well with me however, is that quite often I see what should be considered _domain_ logic ending up in our handlers. [click]

Allowing the domain logic to bleed into our application layer undermines the value of encapsulating all that business logic into a single area of the codebase.

It becomes hard to find those business rules as they're scattered amongst handlers and entities.

Working with our system can quickly become inconsistent and error-prone.

In most projects, I've seen this increasingly normalised combination of the domain and application layers to result in _explicitly_ moving the entire application layer into the domain.
 -->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="400,255,180,180">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label" data-id="presentation">Presentation</div>
</v-drag>

<v-drag pos="430,340,120,_">
  <div class="onion-label view-transition-application-label" data-id="application">Application</div>
</v-drag>

<v-drag pos="450,310,80,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
  <div class="onion-label view-transition-domain-plus">+</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
Very few of the projects I've worked on have actually maintained the distinction between the two &mdash; largely, they have all been reduced to presentation, infrastructure and domain layers.
-->

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="370,225,240,240">
  <div class="onion-domain onion-circle view-transition-domain"></div>
</v-drag>

<v-drag pos="430,195,120,_">
  <div class="onion-label view-transition-presentation-label" data-id="presentation">Presentation</div>
</v-drag>

<v-drag pos="430,340,120,_">
  <div class="onion-label view-transition-application-label" data-id="application">Application</div>
</v-drag>

<v-drag pos="450,310,80,_">
  <div class="onion-label view-transition-domain-label">Domain</div>
  <div class="onion-label view-transition-domain-plus">+</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label">Infrastructure</div>
</v-drag>

<!--
Typically, this has resulted in very thin controllers.

Thin wrappers around a database or services.

And a very busy "domain" project which does pretty much everything.

_Especially_ when we combine this with the approach of allowing our application layer to be aware of, and to map to and from our presentation layer's DTOs.

All of a sudden, we even have elements of our _presentation_ layer creeping into our _domain_ layer.

Even when things are kept relatively clean, we're still relying on _individual developers_ to maintain boundaries instead of putting the appropriate guardrails in place.
-->
