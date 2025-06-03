<template>
  <button
    class="slidev-icon-btn w-8 h-8 reload-code-button"
    onclick="fetch('/.slidev-reload', { method: 'POST' })"
  >
    <div class="i-carbon:restart"></div>
  </button>
</template>

<style>
.reload-code-button {
  position: absolute;
  right: 103px;
  top: 42px;
}
</style>
