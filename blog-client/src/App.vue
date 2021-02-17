<template>
  <div id="app">
    <sidebar-menu
      :menu="menu"
      :class="[{ collapsed: collapsed }, { onmobile: isOnMobile }]"
      :show-one-chile="true"
      @toggle-collapse="onToggleCollapse"
      @item-click="onItemClick"
    />
    <div
      v-if="isOnMobile && !collapsed"
      class="sidebar-overlay"
      @click="collapsed = true"
    />
    <div
      id="RouterView"
      :class="[{ collapsed: collapsed }, { onmobile: isOnMobile }]"
    >
      <router-view class="body" />
      <hr />
      <div class="view-footer">
        聯絡我 : bu9noteblog@gmail.com
        <br />
        Bu9 © 2021.
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      menu: [
        {
          header: true,
          title: " ",
          hiddenOnCollapse: true,
        },
        {
          href: "/",
          title: document.title,
          icon: "fas fa-home",
        },
        {
          href: "/SomethingWrong",
          title: "技術筆記 Technical notes",
          icon: "fas fa-stethoscope",
        },
        {
          href: "/Recipe",
          title: "食譜 Recipe",
          icon: "fas fa-torah",
        },
        {
          href: "/Interview",
          title: "面試筆記 Interview",
          icon: "fas fa-pray",
        },
      ],
      collapsed: false,
      isOnMobile: false,
    };
  },
  mounted() {
    this.onResize;
    window.addEventListener("resize", this.onResize);
  },
  methods: {
    onToggleCollapse(collapsed) {
      console.log(collapsed);
      this.collapsed = collapsed;
    },
    onItemClick(event, item, node) {
      console.log("onItemClock");
      console.log(event);
      console.log(item);
      console.log(node);
    },
    onResize() {
      console.log(process.env.BASE_URL);
      this.isOnMobile = this.collapsed = window.innerWidth <= 767;
    },
  },
};
</script>
