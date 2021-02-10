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
@import url('https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,600');
.v-sidebar-menu .vsm--toggle-btn::after {
  font-family: 'Font Awesome 5 Pro';
  contain: '\f337';

}
</style>