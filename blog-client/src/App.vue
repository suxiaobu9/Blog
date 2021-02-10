<template>
  <div id="app">
   
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
          title:document.title,
          hiddenOnCollapse:true
        },
        {
          href:'/SomethingWrong',
          title:'技術筆記 Technical notes',
          icon:'fas fa-stethoscope'
        },
        {
          href:'/Recipt',
          title:'食譜 Recipt',
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
      this.isOnMobile = this.collapsed = window.innerWidth <= 767;

    }
  }
}
</script>

<style>

.v-sidebar-menu .vsm--title {
  color: #ffa600;
}
</style>