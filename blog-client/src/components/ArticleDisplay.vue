<template>
  <div>
    <markdown-it-vue class="md-body" :content="mdContent" />
  </div>
</template>

<script>
export default {
  name: "ArticleDisplay",
  data() {
    return {
      mdContent: "",
    };
  },
  mounted() {
    this.$http
      .get(
        `https://bu9note.azurewebsites.net/api/blog/getarticle?id=${this.$route.params.id}`
      )
      .then((result) => {
        this.mdContent = result.data;
      })
      .catch((err) => {
        this.mdContent = err;
      });
  },
};
</script>
