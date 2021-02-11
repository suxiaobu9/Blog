<template>
  <div id="app">
    <div id="RouterView" :class="[{'collapsed':collapsed},{'onmobile' : isOnMobile}]">
      <router-view />
    </div>
   <sidebar-menu
    :menu="menu"
    :collapsed="collapsed"
    :show-one-chile="true"
    @toggle-collapse="onToggleCollapse"
    @item-click="onItemClick"
   />
   <div
    v-if="isOnMobile && !collapsed"
    class="sidebar-overlay"
    @click="collapsed = true"
  />
  </div>
</template>

<script>
export default {
  name:'App',
  data(){
    return{
      menu:[
        {
          header:true,
          title:' ',
          hiddenOnCollapse:true
        },
        {
          href:'/',
          title:document.title,
          icon:'fas fa-home'
        },
        {
          href:'/SomethingWrong',
          title:'技術筆記 Technical notes',
          icon:'fas fa-stethoscope'
        },
        {
          href:'/Recipe',
          title:'食譜 Recipe',
          icon:'fas fa-torah'
        },
        {
          href:'/Interview',
          title:'面試筆記 Interview',
          icon:'fas fa-pray'
        }
      ],
      collapsed:false,
      isOnMobile:false
    }
  },
  mounted (){
    this.onResize;
    window.addEventListener('resize', this.onResize);
  },
  methods:{
    onToggleCollapse(collapsed){
      console.log(collapsed);
      this.collapsed = collapsed
    },
    onItemClick(event,item,node){
      console.log('onItemClock');
      console.log(event);
      console.log(item);
      console.log(node);
    },
    onResize(){
      console.log(process.env.BASE_URL)
      this.isOnMobile = this.collapsed = window.innerWidth <= 767;

    }
  }
}
</script>

<style>
html,body{
  margin: 0;
  padding: 0;
}

.v-sidebar-menu .vsm--title {
  color: #ffa600;
}

.v-sidebar-menu .vsm--link.vsm--link_active {
  color: #ffa600;
  box-shadow: 3px 0px 0px 0px #ffa600 inset !important;
  -webkit-box-shadow:3px 0px 0px 0px #2a2a2e inset !important;
}
/*
.v-sidebar-menu .vsm--link.vsm--link_hover{
background-color: #ffa600;
} */

.v-sidebar-menu .vsm--mobile-bg{
  background-color: #2a2a2e !important;
}

.v-sidebar-menu.vsm_collapsed .vsm--link_level-1.vsm--link_hover .vsm--icon, .v-sidebar-menu.vsm_collapsed .vsm--link_level-1:hover .vsm--icon{
  background-color: #ffa600  !important; 
}

#RouterView{
  margin: 50px 100px ;
  padding-left: 350px;
  transition: 0.3s ease;
}

#RouterView.collapsed {
  padding-left: 50px;
}
#RouterView.onmobile {
  padding-left: 50px;
}
</style>