const PROXY_CONFIG = [
  {
    context: [
      "/Task",
      "/User",
    ],
    target: "https://localhost:7100",
    secure: false,
    changeOrigin: true
  }
];

module.exports = PROXY_CONFIG;
