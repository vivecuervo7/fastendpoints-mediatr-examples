import { defineShikiSetup } from "@slidev/types";

export default defineShikiSetup(() => {
  return {
    themes: {
      dark: "dark-plus",
      light: "aurora-x",
    },
    langs: ["csharp"],
    transformers: [],
  };
});
