# Obsidian Knowledge Base — Codex Instructions

This repository is an Obsidian knowledge base. Treat user notes as durable knowledge and keep the user in control of all substantive changes.

## Core principles

1. Default language for notes and conversations is Polish unless the user asks otherwise.
2. Prefer Markdown compatible with Obsidian.
3. Treat existing user notes as authoritative user-owned content.
4. Never perform broad rewrites, bulk reorganizations, deletes, renames, or mass edits unless the user explicitly asks for them.
5. Before editing an existing note, read the relevant file first and preserve its useful structure and intent.
6. Avoid duplicating information that already exists in the same note or in an obvious related note.
7. When useful, suggest links between related notes using Obsidian wikilinks such as `[[Note name]]`, but do not aggressively rewrite the vault just to add links.
8. Prefer small, reviewable changes over large autonomous changes.
9. If a requested operation could affect many files, explain the intended scope before modifying them.

## How to use the vault as context

- When the user references the active note, read it before answering if its content matters.
- When the user points to one or more notes, use only those notes plus clearly necessary related context unless broader vault search is explicitly requested.
- When the user asks a question about existing knowledge, search/read relevant notes before guessing.
- Distinguish clearly between information already present in the vault and new conclusions or suggestions from the model.

## Editing behavior

When the user asks to update a note:

1. Read the target note.
2. Identify the smallest useful change.
3. Preserve existing valuable content.
4. Add or revise only what is needed.
5. Do not modify unrelated notes unless explicitly requested.

When creating a new note:

- Use a clear descriptive filename.
- Use meaningful headings.
- Make the note understandable without requiring the original chat context.
- Prefer concise summaries, explanations, examples, conclusions, and related links where they add value.

## Local AI working memory

Codex may maintain its own local working knowledge under the hidden `.ai/` directory. This directory is for AI operational context only and is not part of the user's knowledge base.

Codex may create and update files there without asking for approval when doing so only improves its own navigation and understanding of the vault.

Useful files may include, as needed:

- `.ai/VAULT_INDEX.md` — lightweight map of important folders, topics, and notable notes.
- `.ai/WORKING_MEMORY.md` — durable operational observations about how this vault is organized and how the user prefers to work with it.
- `.ai/RECENT_CONTEXT.md` — short-lived context useful for continuing work across sessions.
- `.ai/LINK_MAP.md` — optional overview of important relationships between notes when useful.

Do not create files merely for the sake of having them. Create only what materially improves future work.

Keep these files compact and update them when the vault structure or important conventions materially change. Do not copy whole user notes into `.ai/`; store summaries, paths, conventions, and navigation hints instead.

## Important boundary

The `.ai/` directory may be maintained proactively, but user notes must not be changed proactively. Updating internal AI knowledge is allowed; changing the user's actual notes still requires a user request.

## GPT folder

The `gpt/` directory is an inbox for Markdown notes and summaries originating from ChatGPT conversations. More specific instructions for that folder may exist in `gpt/AGENTS.md` and take precedence within that directory.

## Git

- Do not commit or push unless the user explicitly asks or the surrounding integration is already configured by the user to do so automatically.
- Never modify Git history, force-push, reset destructive changes, or discard user work without explicit approval.
- Files under `.ai/` are local AI state and should remain ignored by Git.
