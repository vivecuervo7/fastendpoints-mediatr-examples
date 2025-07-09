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
  <div class="onion-label view-transition-domain-label" data-id="domain" v-mark.red.box="9">Domain</div>
</v-drag>

<v-drag pos="430,470,120,_">
  <div class="onion-label view-transition-infrastructure-label" data-id="infrastructure">Infrastructure</div>
</v-drag>

<v-drag pos="160,172,112,_">
  <div v-click="1" class="floating-label" data-id="request-dto">Request DTO</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=request-dto]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="114,206,96,_">
  <div v-click="1" class="floating-label" data-id="controller">Controller</div>
</v-drag>
<FancyArrow v-click="1" q1="[data-id=presentation]" q2="[data-id=controller]" pos1="top-left" pos2="right" color="orange" arc="-0.05" head-size="20" class="z-100" />

<v-drag pos="629,177,120,_">
  <div v-click="1" class="floating-label" data-id="response-dto">Response DTO</div>
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
  <div v-click="3" class="floating-label" data-id="handler" v-mark.red.box="8">Handler</div>
</v-drag>
<FancyArrow v-click="3" q1="[data-id=application]" q2="[data-id=handler]" pos1="right" pos2="top-left" color="orange" arc="0.1" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=domain]" pos1="left" pos2="right" color="purple" head-size="20" class="z-100" />
<FancyArrow v-click="4" q1="[data-id=handler]" q2="[data-id=infrastructure]" pos1="left" pos2="top-right" color="purple" head-size="20" class="z-100" />

<FancyArrow v-click="2" q1="[data-id=controller]" q2="[data-id=query]" pos1="bottom" pos2="top" color="teal" arc="-0.2" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="5" q1="[data-id=query]" q2="[data-id=mediator]" pos1="bottom" pos2="top-left" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="6" q1="[data-id=mediator]" q2="[data-id=handler]" pos1="bottom" pos2="bottom" color="red" arc="-0.375" width="0.5" head-size="20" class="z-100" />
<FancyArrow v-click="7" q1="[data-id=handler]" q2="[data-id=response-dto]" pos1="top" pos2="right" color="teal" arc="-0.25" width="0.5" head-size="20" class="z-100" />

---

<h1>Why?</h1>
<h2>What's wrong with the current way of doing things?</h2>

<v-drag pos="320,175,340,340">
  <div class="onion-presentation onion-circle view-transition-presentation">
    <hr/>
  </div>
</v-drag>

<v-drag pos="380,235,220,220">
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
…and we end up with this big mess in our domain project, with all the application code lumped in there

FastEndpoints allows us to move that application logic into the presentation layer without overloading an already busy controller
-->