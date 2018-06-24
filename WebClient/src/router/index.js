import Vue from 'vue'
import Router from 'vue-router'
import ScreeningFeed from '@/components/ScreeningsFeed'
import Screening from '@/components/Screening'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'feed',
      component: ScreeningFeed
    },
    {
      path: '/screening/:id',
      name: 'screening',
      component: Screening,
      props: true
    }
  ]
})
