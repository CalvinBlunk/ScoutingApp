	/* Data SHA1: 5767fae4007eef262495af5e70e2a1c7f0228466 */
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	157
	/* entry-length */
	.long	157
	/* value-offset */
	.long	88
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 24650
	.include	"typemap.mj.inc"
