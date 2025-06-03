import { defineConfig } from "vite";
import path from "path";
import fs from "fs";

export default defineConfig({
  plugins: [
    {
      name: "slidev-per-slide-reload-marker",
      configureServer(server) {
        const slidesPath = path.resolve(__dirname, "slides.md");
        // Add middleware to handle POST requests to /.slidev-reload
        server.middlewares.use("/.slidev-reload", (req, res, next) => {
          if (req.method === "POST") {
            let content = fs.readFileSync(slidesPath, "utf8");
            // Find the first <span class="slide-reload-marker" ...>...</span>
            const markerRegex =
              /(<span class=\"slide-reload-marker\"[^>]*>)(.*?)(<\/span>)/s;
            const now = `reload-${Date.now()}`;
            if (markerRegex.test(content)) {
              content = content.replace(markerRegex, `$1${now}$3`);
              fs.writeFileSync(slidesPath, content, "utf8");
              console.log(
                "[slidev] slide-reload-marker updated for per-slide reload",
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
