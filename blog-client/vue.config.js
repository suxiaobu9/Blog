module.exports = {
  chainWebpack: (config) => {
    config.plugin("html").tap((args) => {
      args[0].title = " 菜鳥工程師的通靈之旅 ";
      return args;
    });
  },
};