import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import BookView from '../views/books/View.vue'
import GenreView from '../views/genres/View.vue'
import GenreCreateView from '../views/genres/Create.vue'
import GenreEditView from '../views/genres/Edit.vue'
import AuthorView from '../views/authors/View.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/books',
      name: 'books',
      component: BookView
    },
    {
      path: '/genres',
      name: 'genres',
      component: GenreView
    },
    {
      path: '/authors',
      name: 'authors',
      component: AuthorView
    },
    {
      path: '/genres/create',
      name: 'genreCreate',
      component: GenreCreateView
    },
    {
      path: '/genres/:id/edit',
      name: 'genreEdit',
      component: GenreEditView
    }
  ]
})

export default router
