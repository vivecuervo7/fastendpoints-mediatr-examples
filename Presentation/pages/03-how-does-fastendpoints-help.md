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
...making it much easier to maintain that clear boundary of the domain layer
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
…by having only one endpoint per file that also contains the handler code
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