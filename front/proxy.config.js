const proxy = [
    {
      context: '/api',
      target: 'http://localhost:5000',
      pathRewrite: {'^/api' : '/api/medics/'}
    }
  ];
  module.exports = proxy;