"use strict";!function(n){"function"==typeof define&&define.amd?define(["jquery"],n):"object"==typeof exports?module.exports=n(require("jquery")):n(jQuery)}(function(e){function t(n,i){return this.$el=n,this.options=e.extend({},t.rules.defaults,t.rules[i.rule]||{},i),this.min=Number(this.options.min)||0,this.max=Number(this.options.max)||0,this.$el.on({"focus.spinner":e.proxy(function(n){n.preventDefault(),e(document).trigger("mouseup.spinner"),this.oldValue=this.value()},this),"change.spinner":e.proxy(function(n){n.preventDefault(),this.value(this.$el.val())},this),"keydown.spinner":e.proxy(function(n){var i={38:"up",40:"down"}[n.which];i&&(n.preventDefault(),this.spin(i))},this)}),this.oldValue=this.value(),this.value(this.$el.val()),this}var s,p;t.rules={defaults:{min:null,max:null,step:1,precision:0},currency:{min:0,max:null,step:.01,precision:2},quantity:{min:1,max:999,step:1,precision:0},percent:{min:1,max:100,step:1,precision:0},month:{min:1,max:12,step:1,precision:0},day:{min:1,max:31,step:1,precision:0},hour:{min:0,max:23,step:1,precision:0},minute:{min:1,max:59,step:1,precision:0},second:{min:1,max:59,step:1,precision:0}},t.prototype={spin:function(n){var i;this.$el.prop("disabled")||(this.oldValue=this.value(),i=e.isFunction(this.options.step)?this.options.step.call(this,n):this.options.step,n="up"===n?1:-1,this.value(this.oldValue+Number(i)*n))},value:function(n){if(null==n)return this.numeric(this.$el.val());n=this.numeric(n);var i=this.validate(n);0!==i&&(n=-1===i?this.min:this.max),this.$el.val(n.toFixed(this.options.precision)),this.oldValue!==this.value()&&(this.$el.trigger("changing.spinner",[this.value(),this.oldValue]),clearTimeout(s),s=setTimeout(e.proxy(function(){this.$el.trigger("changed.spinner",[this.value(),this.oldValue])},this),p.delay))},numeric:function(n){return n=(0<this.options.precision?parseFloat:parseInt)(n,10),isFinite(n)?n:n||this.options.min||0},validate:function(n){return null!==this.options.min&&n<this.min?-1:null!==this.options.max&&n>this.max?1:0}},(p=function(n,i){this.$el=e(n),this.$spinning=this.$el.find('[data-spin="spinner"]'),0===this.$spinning.length&&(this.$spinning=this.$el.find(':input[type="text"]')),i=e.extend({},i,this.$spinning.data()),this.spinning=new t(this.$spinning,i),this.$el.on("click.spinner",'[data-spin="up"], [data-spin="down"]',e.proxy(this,"spin")).on("mousedown.spinner",'[data-spin="up"], [data-spin="down"]',e.proxy(this,"spin")),e(document).on("mouseup.spinner",e.proxy(function(){clearTimeout(this.spinTimeout),clearInterval(this.spinInterval)},this)),i.delay&&this.delay(i.delay),i.changed&&this.changed(i.changed),i.changing&&this.changing(i.changing)}).delay=500,p.prototype={constructor:p,spin:function(n){var i=e(n.currentTarget).data("spin");switch(n.type){case"click":n.preventDefault(),this.spinning.spin(i);break;case"mousedown":1===n.which&&(this.spinTimeout=setTimeout(e.proxy(this,"beginSpin",i),300))}},delay:function(n){n=Number(n);0<=n&&(this.constructor.delay=n+100)},value:function(){return this.spinning.value()},changed:function(n){this.bindHandler("changed.spinner",n)},changing:function(n){this.bindHandler("changing.spinner",n)},bindHandler:function(n,i){e.isFunction(i)?this.$spinning.on(n,i):this.$spinning.off(n)},beginSpin:function(n){this.spinInterval=setInterval(e.proxy(this.spinning,"spin",n),100)}};var n=e.fn.spinner;return e.fn.spinner=function(i,t){return this.each(function(){var n=e.data(this,"spinner");n||(n=new p(this,i),e.data(this,"spinner",n)),"delay"===i||"changed"===i||"changing"===i?n[i](t):"step"===i&&t?n.spinning.step=t:"spin"===i&&t&&n.spinning.spin(t)})},e.fn.spinner.Constructor=p,e.fn.spinner.noConflict=function(){return e.fn.spinner=n,this},e(function(){e('[data-trigger="spinner"]').spinner()}),e.fn.spinner});