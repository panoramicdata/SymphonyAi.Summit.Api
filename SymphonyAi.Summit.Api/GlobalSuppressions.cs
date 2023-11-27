// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
	"Style",
	"IDE0046:Convert to conditional expression",
	Justification = "I prefer the readability of if statements here - better maintainability",
	Scope = "member",
	Target = "~M:SymphonyAi.Summit.Api.Implementations.DynamicServiceManager.GetDynamicServiceResultAsync``2(System.String,``0,System.Threading.CancellationToken)~System.Threading.Tasks.Task{``1}"
	)]
