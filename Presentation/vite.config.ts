import { defineConfig } from "vite";
import path from "path";
import fs from "fs";

export default defineConfig({
  plugins: [
    {
      name: "slidev-multi-slide-reload-marker",
      configureServer(server) {
        const slidesPath = path.resolve(__dirname, "slides.md");
        server.middlewares.use("/.slidev-reload", (req, res, next) => {
          if (req.method === "POST") {
            let content = fs.readFileSync(slidesPath, "utf8");
            // Update ALL <span class="slide-reload-marker" ...>...</span> markers
            const markerRegex =
              /(<span class=\"slide-reload-marker\"[^>]*>)(.*?)(<\/span>)/g;
            const now = `reload-${Date.now()}`;
            if (markerRegex.test(content)) {
              content = content.replace(markerRegex, `$1${now}$3`);
              fs.writeFileSync(slidesPath, content, "utf8");
              console.log(
                "[slidev] All slide-reload-markers updated for multi-slide reload",
              );
            } else {
              console.warn(
                "[slidev] No slide-reload-marker found in slides.md",
              );
            }
            res.statusCode = 204;
            res.end();
            return;
          }
          next();
        });
      },
    },
  ],
});
