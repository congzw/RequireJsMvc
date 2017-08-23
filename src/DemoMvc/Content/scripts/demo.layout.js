define('layoutVm', ['vue', 'ELEMENT'], function (Vue, ELEMENT) {

    console.log('from layout define');
    //全局注册饿了么组件
    Vue.use(ELEMENT);

    //全局注册自定义组件（DEMO）
    Vue.component('nb-demo-layout', {
        props: ['text'],
        template: '<div>Shared Component: {{text}}</div>'
    });

    var layoutVm = new Vue({
        el: '#layout',
        data: {
            breadcrumbItems: []
            , demoTree: {
                name: 'DEMO TREE',
                children: [
                  { name: 'hello' },
                  { name: 'wat' },
                  {
                      name: 'child folder',
                      children: [
                        {
                            name: 'child folder',
                            children: [
                              { name: 'hello' },
                              { name: 'wat' }
                            ]
                        },
                        { name: 'hello' },
                        { name: 'wat' },
                        {
                            name: 'child folder',
                            children: [
                              { name: 'hello' },
                              { name: 'wat' }
                            ]
                        }
                      ]
                  }
                ]
            }
        }
    });
    return layoutVm;
});

require(['layoutVm'], function (layoutVm) {

    console.log('from layout require');    console.log(layoutVm);
});