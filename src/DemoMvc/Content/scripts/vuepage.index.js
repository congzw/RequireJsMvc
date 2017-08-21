Vue.component('manage-posts', {
    template: '#manage-template',
    data: function () {
        return {
            posts: [
              'Vue.js: The Basics',
              'Vue.js Components',
              'Server Side Rendering with Vue',
              'Vue + Firebase'
            ]
        }
    }
})